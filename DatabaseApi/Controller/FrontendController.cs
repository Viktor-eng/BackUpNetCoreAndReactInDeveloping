using DataBase.Configurations;
using DatabaseApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApi.Controller
{
    [ApiController]
    public class FrontendController : ControllerBase
    {
        private readonly DatabaseContext _context;


        public FrontendController(DatabaseContext context)
            => _context = context;


        [HttpGet("backupHistory/{backupHistoryId}/logs", Name = "GetHistoryLogsByHistoryBackUpId")]
        public async Task<ActionResult<List<BackUpHistoryLogsViewModel>>> GetHistoryLogsByHistoryBackUpId(int backupHistoryId)
        {
            try
            {
                var listBackUpLogs = await _context
                    .BackUpHistoryLogs
                    .Where(bhl => bhl.BackUpHistoryId == backupHistoryId)
                    .OrderBy(bhl => bhl.Id)
                    .ToListAsync();

                var backUpHistoryLogsViewModel = listBackUpLogs.Select(lbl => (BackUpHistoryLogsViewModel)lbl);

                if (backUpHistoryLogsViewModel != default)
                {
                    return new OkObjectResult(backUpHistoryLogsViewModel);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("database/{databaseId}", Name = "GetDatabaseInfoById")]
        public async Task<ActionResult<DatabaseExtraInfoViewModel>> GetDatabaseInfoById(int databaseId)
        {
            try
            {
                var databaseById = await _context
                    .DatabaseDefinitions
                    .Where(dd => dd.Id == databaseId)
                    .Include(bh => bh.BackUpHistories)
                    .ThenInclude(bhl => bhl.BackUpHistoryLogs)
                    .Include(dd => dd.Drive)
                    .FirstOrDefaultAsync();

                DatabaseExtraInfoViewModel databaseViewModel = databaseById;

                if (databaseViewModel != default)
                {
                    return new OkObjectResult(databaseViewModel);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("database/{databaseId}/backupHistory/{pageNumber}/{pageSize}", Name = "GetBackUpInfoByPage")]
        public async Task<ActionResult<BackUpHistoryPageViewModel>> GetBackUpInfoByPage(int databaseId, int pageNumber, int pageSize)
        {
            try
            {
                BackUpHistoryPageViewModel result = new BackUpHistoryPageViewModel();

                var backUpHistoriesPage = await _context
                  .BackUpHistories
                  .Where(bh => bh.DatabaseDefinitionId == databaseId)
                  .OrderBy(bh => bh.DateTime)
                  .Skip(pageNumber * pageSize)
                  .Take(pageSize)
                  .ToListAsync();

                var backUpHistories = backUpHistoriesPage
                  .Select(bh => (BackUpHistoryViewModel)bh).ToList();

                var pageCount = await _context
                  .BackUpHistories
                  .Where(bh => bh.DatabaseDefinitionId == databaseId)
                  .CountAsync();

                result.PageCurrent = pageNumber;
                result.PageCount = pageCount;
                result.BackUpHistoryViewModels = backUpHistories;

                if (result != default)
                {
                    return new OkObjectResult(result);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("database/{databaseId}/schedules", Name = "GetSchedulePlanByDataBaseId")]
        public async Task<ActionResult<List<ScheduleBackupViewModel>>> GetSchedulePlanByDataBaseId(int databaseId)
        {
            try
            {
                var scheduleBackups = await _context
                    .ScheduleBackups
                    .Where(sb => sb.DatabaseDefinitionId == databaseId)
                    .OrderBy(sb => sb.SchedulePlan)
                    .ToListAsync();

                var scheduleBackupViewModel = scheduleBackups.Select(sbvm => (ScheduleBackupViewModel)sbvm);

                if (scheduleBackupViewModel != default)
                {
                    return new OkObjectResult(scheduleBackupViewModel);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("database/{databaseId}/backupTargets", Name = "GetBackUpTargetsByDataBaseId")]
        public async Task<ActionResult<List<BackUpTargetsViewModel>>> GetBackUpTargetsByDataBaseId(int databaseId)
        {
            try
            {
                var backUpTargets = await _context
                    .BackUpTargets
                    .Include(bt => bt.Drive)
                    .Where(bt => bt.DatabaseDefinitionId == databaseId)
                    .OrderBy(bt => bt.Drive.Letter)
                    .ThenBy(bt => bt.Target)
                    .ToListAsync();

                var backUpTargetsViewModel = backUpTargets.Select(but => (BackUpTargetsViewModel)but);

                if (backUpTargetsViewModel != default)
                {
                    return new OkObjectResult(backUpTargetsViewModel);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("driver", Name = "GetAllDrivers")]
        public async Task<ActionResult<List<DriveViewModel>>> GetAllDrivers()
        {
            try
            {
                var drivers = await _context
                    .Drives
                    .ToListAsync();

                var driversResultViewModels = drivers.Select(d => (DriveViewModel)d);

                if (driversResultViewModels != default)
                {
                    return new OkObjectResult(driversResultViewModels);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("server", Name = "GetAllServers")]
        public async Task<ActionResult<List<ServerResultViewModel>>> GetAllServers()
        {
            try
            {
                var servers = await _context
                    .Servers
                    .OrderBy(s => s.Name)
                    .ToListAsync();

                var serverResultViewModel = servers.Select(s => (ServerResultViewModel)s);

                if (serverResultViewModel != default)
                {
                    return new OkObjectResult(serverResultViewModel);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("server/{serverId}/databases", Name = "GetDatabaseByServerId")]
        public async Task<ActionResult<List<DatabaseInfoViewModel>>> GetDatabaseByServerId(int serverId)
        {
            try
            {
                var databaseDefinitionsByServerId = await _context
                    .DatabaseDefinitions
                    .Where(dd => dd.ServerId == serverId)
                    .OrderBy(dd => dd.Name)
                    .Include(bh => bh.BackUpHistories)
                    .ThenInclude(bhl => bhl.BackUpHistoryLogs)
                    .ToListAsync();

                var lastDatabaseViewModel = databaseDefinitionsByServerId.Select(ddbsi => (DatabaseInfoViewModel)ddbsi);

                if (lastDatabaseViewModel != default)
                {
                    return new OkObjectResult(lastDatabaseViewModel);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("server/{serverId}/sizeHistory/{pageNumber}/{pageSize}/page", Name = "GetServerInfoByPage")]
        public async Task<ActionResult<ServerSizeHistoryPageViewModel>> GetServerInfoByPage(int serverId, int pageNumber, int pageSize)
        {
            try
            {
                ServerSizeHistoryPageViewModel result = new ServerSizeHistoryPageViewModel();

                var serverSizeHistorySortByDate = await _context
                    .ServerSizeHistories
                    .Include(ssh => ssh.ServerToDrive)
                    .ThenInclude(std => std.Drive)
                    .Where(ssh => ssh.ServerId == serverId)
                    .OrderBy(ssh => ssh.DateTime)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var serverSizeHistoryViewModel = serverSizeHistorySortByDate
                  .Select(ssh => (ServerSizeHistoryViewModel)ssh).ToList();

                var pageCount = await _context
                .ServerSizeHistories
                .Where(ssh => ssh.ServerId == serverId)
                .CountAsync();

                result.PageCurrent = pageNumber;
                result.PageCount = pageCount;
                result.ServerSizeHistoryViewModels = serverSizeHistoryViewModel;

                if (result != default)
                {
                    return new OkObjectResult(result);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("server/{serverId}/sizeHistory/{startDate}/{endDate}/period", Name = "GetServerInfoByPeriodDate")]
        public async Task<ActionResult<List<ServerSizeHistoryViewModel>>> GetServerInfoByDate(int serverId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var serverSizeHistorySortByDate = await _context
                        .ServerSizeHistories
                        .Include(ssh => ssh.ServerToDrive)
                        .ThenInclude(std => std.Drive)
                        .Where(ssh => ssh.ServerId == serverId && ssh.DateTime >= startDate && ssh.DateTime <= endDate)
                        .OrderBy(ssh => ssh.DateTime)
                        .ToListAsync();

                System.TimeSpan dt = endDate.Subtract(startDate);

                var serverSizeHistoryViewModel = dt.TotalDays <= 7 ?
                     serverSizeHistorySortByDate
                        .Select(sshsb => (ServerSizeHistoryViewModel)sshsb)
                        .ToList() :
                     serverSizeHistorySortByDate
                        .GroupBy(ssh => ssh.DateTime.Date)
                        .ToDictionary(ssh => ssh.Key, ssh => ssh.First())
                        .Values
                        .Select(sshsb => (ServerSizeHistoryViewModel)sshsb)
                        .OrderBy(ssh => ssh.DateTime.Date)
                        .ToList();

                if (serverSizeHistoryViewModel != default)
                {
                    return new OkObjectResult(serverSizeHistoryViewModel);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("server/{serverId}/driver", Name = "GetDriversByServerId")]
        public async Task<ActionResult<List<DriveViewModel>>> GetDriversByServerId(int serverId)
        {
            try
            {
                var driver = await _context
                    .ServerToDrives
                    .Include(std => std.Drive)
                    .Where(std => std.ServerId == serverId)
                    .Select(d => d.Drive)
                    .OrderBy(d => d.Letter)
                    .ToListAsync();

                var driversResultViewModels = driver
                       .Select(d => (DriveViewModel)d).ToList();

                if (driversResultViewModels != default)
                {
                    return new OkObjectResult(driversResultViewModels);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("storage", Name = "GetAllStorages")]
        public async Task<ActionResult<List<StorageViewModel>>> GetAllStorages()
        {
            try
            {
                var storages = await _context
                    .Storages
                    .OrderBy(s => s.Name)
                    .ToListAsync();

                var storagesResultViewModel = storages;

                if (storagesResultViewModel != default)
                {
                    return new OkObjectResult(storagesResultViewModel);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("storage/{storageId}/sizeHistory/{pageNumber}/{pageSize}", Name = "GetStorageSizeHistoriesByStorageId")]
        public async Task<ActionResult<StorageSizeHistoriesPageViewModel>> GetStorageSizeHistoriesByStorageId(int storageId, int pageNumber, int pageSize)
        {
            try
            {
                StorageSizeHistoriesPageViewModel result = new StorageSizeHistoriesPageViewModel();

                var storageSizeHistories = await _context
                    .StorageSizeHistories
                    .Where(ssh => ssh.StorageId == storageId)
                    .OrderBy(ssh => ssh.DateTime)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var storageSizeViewModel = storageSizeHistories
                        .Select(ssh => (StorageSizeHistoryViewModel)ssh).ToList();

                var pageCount = await _context
                .StorageSizeHistories
                .Where(ssh => ssh.StorageId == storageId)
                .CountAsync();

                result.PageCurrent = pageNumber;
                result.PageCount = pageCount;
                result.StorageSizeHistoryViewModels = storageSizeViewModel;

                if (result != default)
                {
                    return new OkObjectResult(result);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("storage/{storageId}/backUpTarget", Name = "GetBackUpTargetsByStorageId")]
        public async Task<ActionResult<List<BackUpTargetsViewModel>>> GetBackUpTargetsByStorageId(int storageId)
        {
            try
            {
                var backUpTargets = await _context
                    .BackUpTargets
                    .Include(bt => bt.Drive)
                    .Where(bt => bt.StorageId == storageId)
                    .OrderBy(bt => bt.Drive.Letter)
                    .ThenBy(bt => bt.Target)
                    .ToListAsync();

                var backUpTargetsResultViewModel = backUpTargets
                               .Select(d => (BackUpTargetsViewModel)d).ToList();

                if (backUpTargetsResultViewModel != default)
                {
                    return new OkObjectResult(backUpTargetsResultViewModel);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("storage/{storageId}/drive", Name = "GetDrivesByStorageId")]
        public async Task<ActionResult<List<DriveViewModel>>> GetDrivesByStorageId(int storageId)
        {
            try
            {
                var driveByStorageId = await _context
                    .StorageToDrives
                    .Where(std => std.StorageId == storageId)
                    .Select(std => std.Drive)
                    .OrderBy(d => d.Letter)
                    .ToListAsync();

                var driveResultViewModel = driveByStorageId
                                .Select(d => (DriveViewModel)d).ToList();

                if (driveResultViewModel != default)
                {
                    return new OkObjectResult(driveResultViewModel);
                }

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}

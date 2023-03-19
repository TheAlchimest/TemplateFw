using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos;
using TemplateFw.Persistence.Repositories;
using TemplateFw.Shared.Domain.Enums;
using System.Data.SqlClient;
using System.Linq;

public class FaqRepositoryTemplate2
{
    private readonly DbContext _dbContext;

    public FaqRepositoryTemplate2(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateAsync(FaqDto dto)
    {
        _dbContext.Database.ExecuteSqlRaw("[dbo].[Faq_Create] @param1, @param2, @param3",
            new SqlParameter("@param1", dto.Param1),
            new SqlParameter("@param2", dto.Param2),
            new SqlParameter("@param3", dto.Param3)
        );
        return true;
    }

    public async Task<bool> UpdateAsync(FaqDto dto)
    {
        _dbContext.Database.ExecuteSqlRaw("[dbo].[Faq_Update] @param1, @param2, @param3",
            new SqlParameter("@param1", dto.Param1),
            new SqlParameter("@param2", dto.Param2),
            new SqlParameter("@param3", dto.Param3)
        );
        return true;
    }

    public async Task<bool> DeleteVirtuallyAsync(int id, string user)
    {
        _dbContext.Database.ExecuteSqlRaw("[dbo].[Faq_DeleteVirtually] @id, @user",
            new SqlParameter("@id", id),
            new SqlParameter("@user", user)
        );
        return true;
    }

    public async Task<bool> DeletePermanentlyAsync(int id)
    {
        _dbContext.Database.ExecuteSqlRaw("[dbo].[Faq_DeletePermanently] @id",
            new SqlParameter("@id", id)
        );
        return true;
    }

    public async Task<FaqInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
    {
        var result = await _dbContext.Set<FaqInfoDto>().FromSqlRaw("[dbo].[Faq_GetOneInfo] @id, @lang",
            new SqlParameter("@id", id),
            new SqlParameter("@lang", lang)
        ).ToListAsync();
        return result.FirstOrDefault();
    }

    public async Task<List<FaqInfoDto>> GetAllAsync(FaqFilter filter)
    {
        var result = await _dbContext.Set<FaqInfoDto>().FromSqlRaw("[dbo].[Faq_GetAllInfo] @param1, @param2, @param3",
            new SqlParameter("@param1", filter.Param1),
            new SqlParameter("@param2", filter.Param2),
            new SqlParameter("@param3", filter.Param3)
        ).ToListAsync();
        return result;
    }

    public async Task<PagedList<FaqInfoDto>> GetAllInfoPagedAsync(FaqFilter filter)
    {
        var totalCountParam = new SqlParameter("@totalCount", SqlDbType.Int) { Direction = ParameterDirection.Output };
        var parameters = new[]
        {
            new SqlParameter("@param1", filter.Param1),
            new SqlParameter("@param2", filter.Param2),
            new SqlParameter("@param3", filter.Param3),
            new SqlParameter("@pageNumber", filter.PageNumber),
            new SqlParameter("@pageSize", filter.PageSize),
        };
    }
}
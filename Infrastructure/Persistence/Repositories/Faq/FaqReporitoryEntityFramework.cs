using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos;
using TemplateFw.Shared.Domain.Enums;
using Adoler.Dtos;

namespace TemplateFw.Persistence.Repositories.Faq
{
    public class FaqReporitoryEntityFramework
    {
    }
    public class FaqRepository : IFaqRepository
    {
        private readonly ApplicationDbContext _context;

        public FaqRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(FaqDto dto)
        {
            var faq = new Faq()
            {
                Question = dto.Question,
                Answer = dto.Answer,
                IsAvailable = dto.IsAvailable,
                CreatedBy = dto.CreatedBy,
                CreationDate = DateTime.Now
            };

            _context.Faqs.Add(faq);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(FaqDto dto)
        {
            var faq = await _context.Faqs.FindAsync(dto.FaqId);

            if (faq == null)
            {
                return false;
            }

            faq.Question = dto.Question;
            faq.Answer = dto.Answer;
            faq.IsAvailable = dto.IsAvailable;
            faq.LastModifiedBy = dto.LastModifiedBy;
            faq.LastModificationDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            var faq = await _context.Faqs.FindAsync(id);

            if (faq == null)
            {
                return false;
            }

            faq.IsAvailable = false;
            faq.LastModifiedBy = user;
            faq.LastModificationDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            var faq = await _context.Faqs.FindAsync(id);

            if (faq == null)
            {
                return false;
            }

            _context.Faqs.Remove(faq);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<FaqInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            var faq = await _context.Faqs.FindAsync(id);

            if (faq == null)
            {
                return null;
            }

            var infoDto = new FaqInfoDto()
            {
                Question = faq.Question,
                Answer = faq.Answer,
                LanguageId = (int)lang,
                FaqId = faq.FaqId
            };

            return infoDto;
        }

        public async Task<List<FaqInfoDto>> GetAllAsync(FaqFilter filter)
        {
            var faqs = await _context.Faqs
                .Where(f => f.IsAvailable)
                .Select(f => new FaqInfoDto()
                {
                    FaqId = f.FaqId,
                    Question = f.Question,
                    Answer = f.Answer
                })
                .ToListAsync();

            return faqs;
        }

        public async Task<PagedList<FaqInfoDto>> GetAllInfoPagedAsync(FaqFilter filter)
        {
            var query = dbSetReadOnly.AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(filter.SearchTerm))
            {
                query = query.Where(f => f.Question.Contains(filter.SearchTerm) || f.Answer.Contains(filter.SearchTerm));
            }

            if (filter.IsAvailable.HasValue)
            {
                query = query.Where(f => f.IsAvailable == filter.IsAvailable);
            }

            if (filter.CategoryId.HasValue)
            {
                query = query.Where(f => f.CategoryId == filter.CategoryId);
            }

            // Apply paging
            var totalCount = await query.CountAsync();
            var pagedList = await query.OrderBy(f => f.Id)
                                        .Skip((filter.PageNumber - 1) * filter.PageSize)
                                        .Take(filter.PageSize)
                                        .Select(f => new FaqInfoDto
                                        {
                                            Id = f.Id,
                                            Question = f.Question,
                                            Answer = f.Answer,
                                            CategoryId = f.CategoryId,
                                            CategoryName = f.Category.Name,
                                            IsAvailable = f.IsAvailable,
                                            CreationDate = f.CreationDate,
                                            LastModificationDate = f.LastModificationDate
                                        })
                                        .ToListAsync();

            return new PagedList<FaqInfoDto>(pagedList, filter.PageNumber, filter.PageSize, totalCount);
        }

    }
}

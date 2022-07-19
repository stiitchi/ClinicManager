using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Extensions;
using ClinicManager.Domain.Entities.DoctorsAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Doctor.Queries
{
    public class GetAllDoctorsTableQuery : IRequest<PaginatedResult<UserDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllDoctorsTableQuery(int pageNumber, int pageSize, string searchString, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    public class GetAllDoctorsTableQueryHandler : IRequestHandler<GetAllDoctorsTableQuery, PaginatedResult<UserDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllDoctorsTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<UserDTO>> Handle(GetAllDoctorsTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<DoctorEntity, UserDTO>> expression = e => new UserDTO
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    MobileNo = e.MobileNo,
                    WardId = e.WardId
                };

                IQueryable<DoctorEntity> query = _context.Doctors;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.FirstName.Contains(request.SearchString) ||
                                             o.LastName.Contains(request.SearchString) ||
                                             o.Email.Contains(request.SearchString) ||
                                             o.MobileNo.Contains(request.SearchString)
                                             );

                if (request.OrderBy?.Any() != true)
                {
                    var result = await query
                   .AsNoTracking()
                   .IgnoreQueryFilters()
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
                else
                {
                    var ordering = string.Join(",", request.OrderBy);
                    var result = await query
                    .AsNoTracking()
                    .IgnoreQueryFilters()
                    .OrderBy(ordering)
                    .Select(expression)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return await PaginatedResult<UserDTO>.FailureAsync(new List<string> { ex.Message });
            }
        }
    }
}

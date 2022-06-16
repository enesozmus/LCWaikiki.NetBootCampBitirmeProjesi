using AutoMapper;
using LCWaikikiFinal.Application.Features.CategoryOperations.Command;
using LCWaikikiFinal.Application.Features.CategoryOperations.Queries;
using LCWaikikiFinal.Application.Features.ProductOperations.Queries;
using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Application.Mappings;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LCWaikikiFinal.API.Controllers
{
        [EnableCors]
        [Route("api/[controller]")]
        [ApiController]
        public class CategoriesController : ControllerBase
        {
                private readonly IMediator _mediator;

                public CategoriesController(IMediator mediator)
                {
                        _mediator = mediator;
                }

                #region Kategorileri Getir

                [HttpGet]
                public async Task<IActionResult> Get() => Ok(await _mediator.Send(new GetCategoriesQueryRequest()));

                #endregion

                #region Kategori Ekle

                [Authorize(AuthenticationSchemes = "Bearer")]
                //[Authorize(Roles = "Admin, Customer")]
                //[Authorize(Roles = "Admin")]
                [HttpPost]
                public async Task<IActionResult> CreateProduct(CreateCategoryCommandRequest createCategoryCommandRequest) => Ok(await _mediator.Send(createCategoryCommandRequest));

                #endregion
        }
}
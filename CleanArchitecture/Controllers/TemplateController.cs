using CleanArchitecture.Application.DTO;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TemplateController : BaseController<EmployeeDto, Employee>
{
    public TemplateController(IBaseManager<EmployeeDto, Employee> baseManager) : base(baseManager)
    {
    }
}
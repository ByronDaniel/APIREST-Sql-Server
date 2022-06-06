using Microsoft.AspNetCore.Mvc;
using product.Models;
using product.Context;
using BP.Models;
using Microsoft.EntityFrameworkCore;

namespace product.Controllers;

[ApiController]
[Route("[controller]")]
public class CuentaController : ControllerBase
{
    private readonly masterContext context;
    private readonly ILogger<CuentaController> _logger;
    public CuentaController(ILogger<CuentaController> logger, masterContext context)
    {
        _logger = logger;
        this.context = context;
    }

    [HttpGet(Name = "GetCuentas")]
    public ActionResult GetCuentas()
    {
        try
        {
            return Ok(context.cuenta.ToList());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{numero:int}", Name = "GetCuenta")]
    public ActionResult GetCuenta(string numero)
    {
        try
        {
            var cuenta = context.cuenta.FirstOrDefault(u => u.Numero == numero);
            return Ok(cuenta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult PostUsuario(Cuenta cuenta)
    {
        try
        {
            context.cuenta.Add(cuenta);
            context.SaveChanges();
            return CreatedAtRoute("GetCuenta", new { numero = cuenta.Numero}, cuenta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException);
        }
    }


    [HttpPut("{numero:int}")]
    public ActionResult UpdateUsuario(string numero, Cuenta cuenta)
    {
        try
        {
            if (cuenta.Numero == numero)
            {
                context.Entry(cuenta).State = EntityState.Modified;
                context.SaveChanges();
                return CreatedAtRoute("GetCuenta", new { numero = cuenta.Numero}, cuenta);
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{numero:int}")]
    public ActionResult DeleteUsuario(string numero)
    {
        try
        {
            var cuenta = context.cuenta.FirstOrDefault(u => u.Numero == numero);
            if (cuenta != null)
            {
                context.cuenta.Remove(cuenta);
                context.SaveChanges();
                return Ok(numero);
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

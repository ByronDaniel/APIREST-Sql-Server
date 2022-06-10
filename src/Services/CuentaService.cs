using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using product.Api.Infraestructure;
using product.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace product.API.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly masterContext _context;
        public CuentaService(masterContext context)
        {
            _context = context;
        }
        List<Cuenta> ICuentaService.GetCuentas()
        {
            List<Cuenta> cuentas = _context.cuenta.ToList();
            if(cuentas.Count == 0)
            {
                throw new Exception("No existen cuentas");
            }
            return cuentas;
        }

        Cuenta ICuentaService.GetCuenta(string numero)
        {
            Cuenta cuenta = _context.cuenta.FirstOrDefault(cuenta => cuenta.Numero == numero);
            if(cuenta == null)
            {
                throw new Exception("No existe la cuenta");
            }
            return cuenta;
        }

        Cuenta ICuentaService.PostCuenta(Cuenta cuenta)
        {
            try
            {
                _context.cuenta.Add(cuenta);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo crear la cuenta");
            }
            return cuenta;
        }

        Cuenta ICuentaService.UpdateCuenta(Cuenta cuenta)
        {
            try
            {
                _context.Entry(cuenta).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cuenta;
        }
        
        String ICuentaService.DeleteCuenta(string numero)
        {
            var cuenta = _context.cuenta.FirstOrDefault(u => u.Numero == numero);
            try
            {
                if (cuenta != null)
                {
                    _context.cuenta.Remove(cuenta);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("No existe la cuenta a eliminar");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return numero;
        }
    }
}

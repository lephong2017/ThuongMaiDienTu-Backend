﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReflectionIT.Mvc.Paging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TemplateWebApiPhucThinh.Data.Model;

using TemplateWebApiPhucThinh.ModelValidation;
using TemplateWebApiPhucThinh.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
namespace TemplateWebApiPhucThinh.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //ICustomerRepository CustomerRepository;
        //IMapper Mapper;
        //IConfiguration Configuration;
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Customer Customer)
        {
            //   var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToDictionary( t => t.Type, t => t.Value);
            // if(claims.ContainsKey("name")){
            //     if( claims["name"].Equals("ADMIN") || claims["name"].Equals("MANAGER") ){
                    Customer.Id = Guid.NewGuid() + "";
                    Customer.IsDelete=false;
                    return Ok(_repository.Create(Customer));
            //     }
            // }else{
            //     return Forbid();
            // }
            //     return Forbid();
          
        }
     
        [Authorize()]
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(string id)
        {
             var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToDictionary( t => t.Type, t => t.Value);
            if(claims.ContainsKey("name")){
                if( claims["name"].Equals("ADMIN") || claims["name"].Equals("MANAGER") ){
                    return Ok(_repository.GetById(id));
                }
            }else{
                return Forbid();
            }
                return Forbid();
            
        }

        [Authorize()]
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToDictionary( t => t.Type, t => t.Value);
            if(claims.ContainsKey("name")){
                if( claims["name"].Equals("ADMIN") || claims["name"].Equals("MANAGER") ){
                   return Ok(_repository.Delete(id));
                }
            }else{
                return Forbid();
            }
                return Forbid();
           
        }

        [Authorize()]
        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult Update(string id, [FromBody] Customer Customer)
        {
            var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToDictionary( t => t.Type, t => t.Value);
            if(claims.ContainsKey("name")){
                if( claims["name"].Equals("ADMIN") || claims["name"].Equals("MANAGER") ){
                    return Ok(_repository.Update(id, Customer));
                }
            }else{
                return Forbid();
            }
                return Forbid();
           
        }

        // [Authorize()]
        [HttpGet]
        [Route("Paging/pagesize/pageNow")]
        public IActionResult Paging(int pagesize, int pageNow)
        {
            //   var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToDictionary( t => t.Type, t => t.Value);
            // if(claims.ContainsKey("name")){
            //     if( claims["name"].Equals("ADMIN") || claims["name"].Equals("MANAGER") ){
                    return Ok(_repository.Paging(pagesize, pageNow, "color"));
            //     }
            // }else{
            //     return Forbid();
            // }
            //     return Forbid();
        }

        [Authorize()]
         [HttpGet]
        [Route("CountOfPaging/pagesize/pageNow")]
        public IActionResult CountOfPaging(int pagesize, int pageNow)
        {
             var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToDictionary( t => t.Type, t => t.Value);
            if(claims.ContainsKey("name")){
                if( claims["name"].Equals("ADMIN") || claims["name"].Equals("MANAGER") ){
                    return Ok(_repository.CountOfPaging(pagesize, pageNow));
                }
            }else{
                return Forbid();
            }
                return Forbid();
        }

        [Authorize()]
         [HttpGet]
        [Route("CountAll/pagesize/pageNow")]
        public IActionResult CountAll(int pagesize, int pageNow)
        {
             var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToDictionary( t => t.Type, t => t.Value);
            if(claims.ContainsKey("name")){
                if( claims["name"].Equals("ADMIN") || claims["name"].Equals("MANAGER") ){
                   return Ok(_repository.CountAll());
                }
            }else{
                return Forbid();
            }
                return Forbid();
        }

        [Authorize()]
        [HttpDelete]
        [Route("DeleteEnable/{id}")]
        public IActionResult DeleteEnable(string id)
        {
            
             var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToDictionary( t => t.Type, t => t.Value);
            if(claims.ContainsKey("name")){
                if( claims["name"].Equals("ADMIN") || claims["name"].Equals("MANAGER") ){
                    if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            return Ok(_repository.DeleteEnable(id));
                }
            }else{
                return Forbid();
            }
                return Forbid();
           
        }


        [Authorize()]
        [HttpGet]
        [Route("PagingCondition/pagesize/pageNow/condition")]
        public IActionResult PagingCondition(int pagesize, int pageNow,string condition)
        {
             var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToDictionary( t => t.Type, t => t.Value);
            if(claims.ContainsKey("name")){
                if( claims["name"].Equals("ADMIN") || claims["name"].Equals("MANAGER") ){
                    return Ok(_repository.PagingCondition(pagesize, pageNow, condition));
                }
            }else{
                return Forbid();
            }
                return Forbid();
            
            

        }

        [Authorize()]
        [HttpGet]
        [Route("CountCondition/condition")]
        public IActionResult CountCondition(string condition)
        {
               var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToDictionary( t => t.Type, t => t.Value);
            if(claims.ContainsKey("name")){
                if( claims["name"].Equals("ADMIN") || claims["name"].Equals("MANAGER") ){
                    return Ok(_repository.CountCondition(condition));
                }
            }else{
                return Forbid();
            }
                return Forbid();
           
        }

        [Authorize()]
        [HttpGet]
        [Route("PagingConditionPrice/condition/pageIndex/pageSize/sortOrder/priceStart/priceEnd")]
        public IActionResult PagingConditionPrice(string condition, int pageIndex, int pageSize, string sortOrder, int priceStart, int priceEnd)
        {
            var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToDictionary( t => t.Type, t => t.Value);
            if(claims.ContainsKey("name")){
                if( claims["name"].Equals("ADMIN") || claims["name"].Equals("MANAGER") ){
                     return Ok(_repository.PagingConditionPrice( condition,  pageIndex,  pageSize,  sortOrder,  priceStart,  priceEnd));
                }
            }else{
                return Forbid();
            }
                return Forbid();
            
        }
    }
}

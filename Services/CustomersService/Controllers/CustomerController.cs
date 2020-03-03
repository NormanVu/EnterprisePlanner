using CustomersBusiness.Helpers;
using CustomersBusiness.Models;
using CustomersService.Entities;
using CustomersService.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace CustomersService.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repo;

        public CustomerController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetCustomers(CustomersPagingParameters customerParams)
        {
            try
            {
                var customersFromRepo = _repo.GetCustomers(customerParams).ToList();
                var customers = Mapper.Map<IEnumerable<CustomerDTO>>(customersFromRepo);
                CustomersPagedResult result = new CustomersPagedResult
                {
                    TotalResultCount = _repo.GetResultCount(),
                    data = customers.ToList()
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetCustomer([FromRoute]int id)
        {
            try
            {
                if (!_repo.CustomerExists(id)) { return NotFound(); }
                var customer = Mapper.Map<CustomerDTO>(_repo.GetCustomer(id));
                return Ok(customer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody]CustomerDTO customerToCreate)
        {
            try
            {
                if (customerToCreate == null) return BadRequest();

                if (!ModelState.IsValid)
                {
                    return new WebApiHelpers.ObjectResults.UnprocessableEntityObjectResult(ModelState);
                }

                var customerEntity = Mapper.Map<Customer>(customerToCreate);
                _repo.AddCustomer(customerEntity);
                if (!_repo.Save())
                {
                    throw new Exception("Error creating customer.");
                }
                var customerToReturn = Mapper.Map<CustomerDTO>(customerEntity);
                return CreatedAtRoute("GetCustomer", new { id = customerToReturn.Id }, customerToReturn);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody]CustomerDTO customerToUpdate)
        {
            if (customerToUpdate == null) return BadRequest();

            if (!ModelState.IsValid)
            {
                return new WebApiHelpers.ObjectResults.UnprocessableEntityObjectResult(ModelState);
            }

            var customerFromRepo = _repo.GetCustomer(id);
            if (customerFromRepo == null) return NotFound();
            try
            {
                Mapper.Map(customerToUpdate, customerFromRepo);
                _repo.UpdateCustomer(customerFromRepo);
                _repo.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customerFromRepo = _repo.GetCustomer(id);
            if (customerFromRepo == null) return NotFound();
            _repo.DeleteCustomer(customerFromRepo);
            if (!_repo.Save())
            {
                throw new Exception($"Error deleting customer {id}.");
            }

            return NoContent();
        }
    }
}

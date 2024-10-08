﻿using CarConnect.Models;
using CarConnect.Repository.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarConnect.Exceptions.CustomExceptions;

namespace CarConnect.Service.CustomerService
{
    internal class CustomerService : ICustomerService
    {
        readonly ICustomerRepo customerRepo;
        public CustomerService()
        {
            customerRepo = new CustomerRepo();
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = customerRepo.GetCustomerById(id);
            if (customer == null)
            {
                throw new Exception($"Customer with ID {id} not found.");
            }
            return customer;
        }

        public Customer GetCustomerByUsername(string name)
        {
            Customer customer = customerRepo.GetCustomerByUsername(name);
            if (customer == null)
            {
                throw new AuthenticationException("Username does not exist.");
            }
            return customer;
        }

        public void RegisterCustomer(Customer customer)
        {
            try
            {
                int registerStatus = customerRepo.RegisterCustomer(customer);
                if (registerStatus > 0)
                {
                    Console.WriteLine("Customer added successfully.");
                }
                else
                {
                    Console.WriteLine("Customer addition failed.");
                }
            }
            catch (UniqueConstraintViolationException ex)
            {
                Console.WriteLine(ex.Message); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        public void UpdateCustomer(int id, Customer customer)
        {
            int registerStatus = customerRepo.UpdateCustomer(id, customer);
            if (registerStatus > 0)
            {
                Console.WriteLine("Customer updated Successfully");
            }
            else
            {
                Console.WriteLine("Updation Failed");
            }
        }

        public void DeleteCustomer(int id)
        {
            int registerStatus = customerRepo.DeleteCustomer(id);
            if (registerStatus > 0)
            {
                Console.WriteLine("Customer deleted Successfully");
            }
            else
            {
                Console.WriteLine("Deletion Failed");
            }
        }
    }
}

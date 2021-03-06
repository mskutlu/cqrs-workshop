﻿using Microsoft.EntityFrameworkCore;
using OrderApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OrderApi.Data.Repositories.MsSql
{
    public interface IOrderRepository
    {
        Task Create(Order order);

        Task Update(Order order);

        Task<Order> Get(string orderCode);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly WorkshopDbContext _dbContext;

        public OrderRepository(WorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Order order)
        {
            await _dbContext.AddAndSaveAsync(order);
        }

        public async Task Update(Order order)
        {
            await _dbContext.UpdateAndSaveAsync(order);
        }

        public async Task<Order> Get(string orderCode)
        {
            return await _dbContext.Orders.SingleOrDefaultAsync(x => x.OrderCode == orderCode);
        }
    }
}

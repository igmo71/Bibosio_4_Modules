using Bibosio.StorageModule.Domain;
using Bibosio.StorageModule.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibosio.StorageModule.Application
{
    internal class StorageCommandService : IStorageCommandService
    {
        public async Task TransferItems(Transfer transfer)
        {
            // Обновляем количество в исходной и целевой ячейке
            //var fromStock = await _context.Stocks.FirstOrDefaultAsync(s => s.StorageLocationId == transfer.FromLocationId && s.ProductId == transfer.ProductId).;
            //var toStock = await _context.Stocks.FirstOrDefaultAsync(s => s.StorageLocationId == transfer.ToLocationId && s.ProductId == transfer.ProductId);

            //if (fromStock == null || fromStock.Quantity < transfer.Quantity)
            //{
            //    return BadRequest("Недостаточное количество товара для перемещения.");
            //}

            //fromStock.Quantity -= transfer.Quantity;

            //if (toStock != null)
            //{
            //    toStock.Quantity += transfer.Quantity;
            //}
            //else
            //{
            //    _context.Stocks.Add(new Stock
            //    {
            //        ProductId = transfer.ProductId,
            //        StorageLocationId = transfer.ToLocationId,
            //        Quantity = transfer.Quantity
            //    });
            //}

            //_context.Transfers.Add(transfer);
            //await _context.SaveChangesAsync();

            //return Ok();
        }
    }
}

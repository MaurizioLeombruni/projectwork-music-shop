﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopStrumentiMusicali.Models
{

    //Classe che gestisce il rifornimento del negozio
    public class ShopTransaction
    {
        public int Id { get; set; }

        public string SupplierName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TransactionDate { get; set; }

        [Column(TypeName = "smallint")]
        [Range(0, 32000, ErrorMessage = "Invalid input for quantity")]
        public int TransactionQuantity { get; set; }

        [Column(TypeName = "int")]
        [Range(0, 200000, ErrorMessage = "Invalid input for supplier's fee")]
        public double TransactionFee { get; set; }

        public int InstrumentID { get; set; }
        public Instrument Instrument { get; set; }

        //FKs

        public ShopTransaction() { }

        public ShopTransaction(string supplierName, DateTime? transactionDate, int transactionQuantity, double transactionFee)
        {
            SupplierName = supplierName;
            TransactionDate = transactionDate;
            TransactionQuantity = transactionQuantity;
            TransactionFee = transactionFee;
        }
    }
}

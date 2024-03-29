﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShopStrumentiMusicali.Models
{
    public class Instrument
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100, ErrorMessage="Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(300)")]
        [StringLength(300, ErrorMessage = "Image URL cannot be longer than 300 characters.")]
        public string ImageURL { get; set; }

        public double Price { get; set; }

		[Column(TypeName = "int")]
		[Range(0,500000, ErrorMessage = "Invalid value for stock quantity")]
        public int? Quantity { get; set; }

		[Column(TypeName = "int")]
		[Range(0, 500000, ErrorMessage = "Invalid value for user likes")]
		public int? UserLikes { get; set; }
        public string? State { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

        public List<UserTransaction>? UserTransactions { get; set; }

        public List<ShopTransaction>? ShopTransactions { get; set; }

        public Instrument() { UserLikes = 0; }

        public Instrument(string name, string description, string imageURL)
        {
            Name = name;
            Description = description;
            ImageURL = imageURL;
            UserLikes= 0;
        }
    }
}

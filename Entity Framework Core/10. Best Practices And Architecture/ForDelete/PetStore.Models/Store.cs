﻿using PetStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Models
{
    public class Store
    {
        public Store()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Pets=new HashSet<Pet>();   
            this.Products= new HashSet<Product>();   
            this.Services = new HashSet<Service>();     
        }
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(StoreValidationConstants.NAME_MAX_LENGTH)]

        public string Name { get; set; }

        [MaxLength(StoreValidationConstants.DESCRIPTION_MAX_LENGTH)]

        public string Description { get; set; }

        [Required]
        [MaxLength(StoreValidationConstants.WORK_TIME_MAX_LENGTH)]

        public string WorkTime { get; set; }

        [Required]
        [MaxLength(StoreValidationConstants.EMAIL_MAX_LENGTH)]

        public string Email { get; set; }

        [Required]
        [MaxLength(StoreValidationConstants.PHONE_NUMBER_MAX_LENGTH)]

        public string PhoneNumber { get; set; }


        [Required]
        [ForeignKey(nameof(Address))]

        public string AddressId { get; set; }

        public virtual Address Address { get; set; }


        public virtual ICollection<Pet> Pets { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Service> Services { get; set; }

    }
}

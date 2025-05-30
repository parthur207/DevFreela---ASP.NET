﻿using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Models
{
    public class CreateProjectModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreeLancer { get; set; }
        public decimal TotalCost { get; set; }  
    }
}

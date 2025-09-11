﻿using Api.Models.Exams;

namespace Api.Models.Identity
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public List<ExamTemplate> ExamTemplates { get; set; } = new();
    }
}


using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;

namespace TemplateFw.Dtos
{
	public class FaqDto
	{
		public int FaqId { get; set; }
		public string QuestionAr { get; set; }
		public string QuestionEn { get; set; }
		public string AnswerAr { get; set; }
		public string AnswerEn { get; set; }
		public int PortalId { get; set; }
		public int? ServiceId { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
		public string LastModifiedBy { get; set; }
		public DateTime? LastModificationDate { get; set; }

	}

	public class FaqInfoDto
	{
		public int FaqId { get; set; }
		public string Question { get; set; }
		public string Answer { get; set; }
		public int PortalId { get; set; }
		public string PortalName { get; set; }
		public int? ServiceId { get; set; }
		public string ServiceName { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
		public string LastModifiedBy { get; set; }
		public DateTime? LastModificationDate { get; set; }
	}

	public class FaqFilter
	{
		public string Question { get; set; }
		public int? PortalId { get; set; }
		public int? ServiceId { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
	}
}

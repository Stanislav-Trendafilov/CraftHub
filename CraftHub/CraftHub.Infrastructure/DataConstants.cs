namespace CraftHub.Infrastructure
{
	public static class DataConstants
	{
		//Data Constants for Creator entity model
		public const int CreatorPhoneNumberMinLength = 7;
		public const int CreatorPhoneNumberMaxLength = 15;

		public const int CreatorsBusinessNameMinLength = 2;
		public const int CreatorsBusinessNameMaxLength = 50;

		public const int CreatorFullNameMinLength = 5;
		public const int CreatorFullNameMaxLength =70;

		public const int CreatorsMoreInformationMaxLength = 250;

		//Data Constants for ProductCategory entity model
		public const int ProductCategoryNameMinLength = 3;
		public const int ProductCategoryNameMaxLength = 50;

		//Data Constants for Product entity model
		public const int ProductTitleMinLength = 5;
		public const int ProductTitleMaxLength = 50;

		public const int ProductDescriptionMinLength = 5;
		public const int ProductDescriptionMaxLength = 100;

		public const double ProductPriceMinimum = 0.00;
		public const double ProductPriceMaximum = 10000.00;

		//Data Constants for the Course
		public const int TitleMinLength = 3;
		public const int TitleMaxLength = 50;

		public const int LecturerMinLength = 5;
		public const int LecturerMaxLength = 50;

		public const int DetailsMinLength = 5;
		public const int DetailsMaxLength = 150;

		public const int DurationMinLength = 1;
		public const int DurationMaxLength = 24;

		//Data Constants for the Lection
		public const int TopicMinLength = 3;
		public const int TopicMaxLength = 50;
	}
}
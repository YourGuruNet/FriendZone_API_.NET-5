using Domain;
using FluentValidation;

namespace Application.Activities
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
        //Check activity, trow error if one of fields is empty
        public ActivityValidator()
        {
            RuleFor(activity => activity.Title).NotEmpty();
            RuleFor(activity => activity.Venue).NotEmpty();
            RuleFor(activity => activity.Description).NotEmpty();
            RuleFor(activity => activity.City).NotEmpty();
            RuleFor(activity => activity.Date).NotEmpty();
            RuleFor(activity => activity.Venue).NotEmpty();
        }
    }
}
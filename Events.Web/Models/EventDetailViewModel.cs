using Events.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Events.Web.Models
{
    public class EventDetailViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Event, EventDetailViewModel>> ViewModel
        {
            get
            {
                return e => new EventDetailViewModel()
                {
                    Id = e.Id,
                    Description = e.Description,
                    AuthorId = e.AuthorId,
                    Comments = e.Comments.AsQueryable().Select(CommentViewModel.ViewModel)
                };
            }
        }
    }
}
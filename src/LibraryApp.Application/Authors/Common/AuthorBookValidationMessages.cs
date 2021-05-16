namespace LibraryApp.Application.Authors.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class AuthorBookValidationMessages
    {
        public static string BookDoesntExist = "Book doesn't exist.";

        public static string WrongAuthorBookCombination = "No such book exists on this author.";
    }
}

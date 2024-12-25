using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogService.Messaging
{
    public class Messages
    {
        public const string ProductCreated = "Product has been successfully created.";
        public const string ProductUpdated = "Product has been successfully updated.";
        public const string ProductDeleted = "Product has been successfully deleted.";

        // Error Messages
        public const string ProductNotFound = "Product with the specified ID was not found.";
        public const string InvalidProductId = "The provided product ID is invalid.";
        public const string CategoryNotFound = "The specified category does not exist.";
        public const string ValidationError = "One or more validation errors occurred.";

        // Information Messages
        public const string NoProductsAvailable = "No products are available at the moment.";

        // General Messages
        public const string UnexpectedError = "An unexpected error occurred. Please try again later.";

    }
}
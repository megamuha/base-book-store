﻿namespace Acme.BookStore.Permissions
{
    public static class BookStorePermissions
    {
        public const string GroupName = "BookStore";

        public static class Books
        {
            public const string Default = GroupName + ".Books";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
            public const string Buy = Default + ".Buy";
        }

        public static class Authors
        {
            public const string Default = GroupName + ".Authors";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";

        }

        public static class OrderedBooks
        {
            public const string Default = GroupName + ".Orders";
            public const string Delete = Default + ".Delete";
            public const string ShowOrders = Default + ".ShowOrders";
            public const string ChangeStatus = Default + ".ChangeStatus";

        }
    }
}
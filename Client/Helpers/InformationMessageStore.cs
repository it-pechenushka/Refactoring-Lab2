namespace Client.Helpers
{
    public static class InformationMessageStore
    {
        public const string UsageCommandsMessage = "Usage:\n" +
                                            "       Type one of commands:\n" +
                                            "               \"list\": display all items of catalog\n" +
                                            "               \"search\": find item in catalog\n" +
                                            "               \"add\": add new item\n" +
                                            "               \"del\": remove some item from list\n" +
                                            "               \"register\": create new user\n" +
                                            "               \"login\": login as existing user\n" +
                                            "               \"logout\": logout\n" +
                                            "               \"quit\": exit from program";

        public const string InputCommandMessage = "\n[Input command]:";
        public const string ListCommandMessage = "All Compositions In Catalog:";
        public const string SearchCommandMessage = "Input the part of the name to find composition in the catalog:";
        public const string NotFoundResultMessage = "No track found.";
        public const string InputAuthorMessage = "Input author's name:";
        public const string InputCompositionMessage = "Input the compositions's name:";
        public const string DeleteCommandMessage = "Input the full name of the track to remove:";
        public const string AddSuccessCommandMessage = "Track {0} added.";
        public const string DeleteSuccessMessage = "Track {0} deleted.";
        public const string InputUserNameMessage = "Input user login:";
        public const string InputUserPasswordMessage = "Input password:";
        public const string AddUserSuccessCommandMessage = "User {0} successfully added";
        public const string LoginSuccessCommandMessage = "Successfully signed in";
        public const string LogoutSuccessCommandMessage = "Successfully signed out";
    }
}

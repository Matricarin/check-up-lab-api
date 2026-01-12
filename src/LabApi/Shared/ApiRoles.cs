using JetBrains.Annotations;

namespace LabApi.Shared;

public static class ApiRoles
{
    public const string Admin = "admin";

    [UsedImplicitly] public static IReadOnlyList<string> AllRoles = Array.AsReadOnly([Admin, Consumer]);

    public const string Consumer = "Consumer";

    public static string DefaultRole => Consumer;
}
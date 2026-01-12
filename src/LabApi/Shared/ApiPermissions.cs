using JetBrains.Annotations;

namespace LabApi.Shared;

public static class ApiPermissions
{
    [UsedImplicitly] public static IReadOnlyList<string> AllPermissions =
        Array.AsReadOnly([ClinicalTestsRead, ClinicalTestsCreate, ClinicalTestsDelete, ClinicalTestsUpdate]);

    [UsedImplicitly] public static IReadOnlyList<string> DefaultPermissions = Array.AsReadOnly([ClinicalTestsRead]);

    public const string ClinicalTestsCreate = "clinical_tests.create";
    public const string ClinicalTestsDelete = "clinical_tests.delete";
    public const string ClinicalTestsRead = "clinical_tests.read";
    public const string ClinicalTestsUpdate = "clinical_tests.update";
    public const string PermissionClaimType = "permission";
}
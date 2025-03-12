
using DunktonPublicLibrary.App.Domain.Entities;

namespace DunktonPublicLibrary.App.Application;

public static class AccountLoggedIn
{
    private static Account? _account;

    public static bool IsTokenSet => _account is not null && _account.Token is not null;
    public static void SetAccount(Account? account) => _account = account;
}

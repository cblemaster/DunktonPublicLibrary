using DunktonPublicLibrary.App.Domain.Entities;

namespace DunktonPublicLibrary.App.Application;

public static class AccountLoggedIn
{
    private static Account? _account;

    public static void SetAccount(Account account) => _account = account;
}

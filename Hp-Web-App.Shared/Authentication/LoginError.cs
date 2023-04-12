namespace Hp_Web_App.Shared.Authentication;

public enum LoginError
{
    InvalidCredentials,
    MissingUserEmail,
    MissingUserRole,
    UnknownUserRole,
    InvalidPassword,
    None
}

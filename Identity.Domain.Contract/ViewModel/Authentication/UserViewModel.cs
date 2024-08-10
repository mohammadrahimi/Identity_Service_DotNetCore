namespace Identity.Domain.Contract.ViewModel.Authentication;

public record UserViewModel(
    string firstname,
    string lastname,
    string password,
    string mobileNumber,
    string mobileCountry,
    string city,
    string codeposti
    );


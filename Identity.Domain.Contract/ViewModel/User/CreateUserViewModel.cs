

namespace Identity.Domain.Contract.ViewModel.User;

public record CreateUserViewModel(
    string fname,
    string lname,
    string mNumber,
    string mCountry,
    string city,
    string codeposti,
    string password );
 

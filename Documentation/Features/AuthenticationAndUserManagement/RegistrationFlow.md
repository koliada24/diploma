# Registration Flow

User enters all the data (login, password, email, name and surname) and clicks "Submit".

What happens?

### Validation and credentials storing

Request sends to the Authentication Service. There it is validated: Does user with such login already exist? Is email already taken? Does password meet password policy?

After all the validation, service stores credentials and issues the JWT and refresh token.

Also service put JWT into cookies for authentication in other services. 

### Public profile storing
For saving the profile data, Authentication Service emits UserRegistered event. User Profile service listen for this event and then after the validation stores profile data to the db.
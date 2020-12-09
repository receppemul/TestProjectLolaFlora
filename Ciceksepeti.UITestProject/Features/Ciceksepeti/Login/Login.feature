Feature: Login
	Login sayfası kontrolleri yapılır


	Scenario: LoginValidation
	* 'https://www.lolaflora.com/login' sitesine gidilir
	* Menü elementinin bulunduğu görülür
	* Email elementinin bulunduğu görülür
	* Password elementinin bulunduğu görülür
	* SignIn elementinin bulunduğu görülür
	* Forgot Password elementinin bulunduğu görülür
	* Sign In with Facebook elementinin bulunduğu görülür
	* SignUp elementinin bulunduğu görülür
	

	Scenario: SuccesLogin
	* 'https://www.lolaflora.com/login' sitesine gidilir
	* Email alanına 'uitestflora@gmail.com' yazılır
	* Password alanına 'UiTestFlora123.' yazılır
	* Sign In butonuna tıklanır 
	* 5 saniye beklenir
	* Giriş yapıldığı görülür
	* 3 saniye beklenir

    Scenario: FailLogin
	* 'https://www.lolaflora.com/login' sitesine gidilir
	* Email alanına 'test@gmail.com' yazılır
	* Password alanına 'test.' yazılır
	* Sign In butonuna tıklanır 
	* 3 saniye beklenir
	* 'E-mail address or password is incorrect. Please check your information and try again.' uyarısı geldiği görülür

	Scenario: EnterEmptyMailandPasswordControl
	* 'https://www.lolaflora.com/login' sitesine gidilir
	* Email alanına ' ' yazılır
	* Password alanına ' ' yazılır
	* Sign In butonuna tıklanır 
	* 3 saniye beklenir
	* Email alanında Required field. uyarı mesajı geldiği görülür
	* Password alanında Required field. uyarı mesajı geldiği görülür 
	

	Scenario: PasswordControl
	* 'https://www.lolaflora.com/login' sitesine gidilir
	* Password alanına 'test.' yazılır
	* Password alanının gizli olduğu görülür
	* ShowPassword butonuna tıklanır
	* 1 saniye beklenir 
	* Password alanının gizlenmediği görülür

	Scenario: ForgotPasswordControl
	* 'https://www.lolaflora.com/login' sitesine gidilir
	* Forgot Password butonuna tıklanır
	* Mail alanına 'uitestflora@gmail.com' yazılır
	* Send butonuna tıklanır 
	* 3 saniye beklenir
	* You will receive an e-mail from us with instructions for resetting your password. bilgilendirme mesajı geldiği görülür
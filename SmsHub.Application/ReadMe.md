This is a class library project.
It includes Application project in Clean Architecture teminology:
	- (Mostely) Invokes `Infrastructure` project
	- Ensure policy match, for instance ensure that no sms length is above 1024 charachters
	- Basic validations
	- This layer must be responsible to the API project
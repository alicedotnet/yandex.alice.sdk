# How to contribute to a project

## Local setup
Clone the repository and make sure necessary tests run successfully.
There are three test projects:

There are three test projects:
### Yandex.Alice.Sdk.Tests
Has tests for the library that pushed as NuGet package. You may need to check tests from this project in case you're making updates related to the processing of requests to a skill.
Prerequisites: No

### Yandex.Alice.Sdk.Demo.IntegrationTests
Has tests for a General skill demo project. You may need to check tests from this project in case you're making updates to API related to general skills.
Prerequisites: User secrets in the following format
```json
{
  "AliceSettings": {
    "SkillId": "id of your general skill",
    "DialogsOAuthToken": "OAuth token for dialogs"
  }
}
```
- SkillId. Can get it from [the developer console](https://dialogs.yandex.ru/developer/). Example of the value: 11cfdd61-7473-4b54-aae2-612434056e3f
- DialogsOAuthToken. Check [documentation](https://yandex.ru/dev/dialogs/alice/doc/resource-upload.html#http-images-load__auth).

### Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests
Has tests for a Smart home skill demo project. You may need to check tests from this project in case you're making updates to API related to smart home skills.

Prerequisites: User secrets in the following format
```json
{
  "AliceSettings": {
    "SmartHomeSkillId": "id of your smart home skill",
    "DialogsOAuthToken": "OAuth token for dialogs",
    "IoTOAuthToken": "IoT OAuth token"
  }
}

```
- SmartHomeSkillId. Can get it from [the developer console](https://dialogs.yandex.ru/developer/). Example of the value: 11cfdd61-7473-4b54-aae2-612434056e3f
- DialogsOAuthToken. Check [documentation](https://yandex.ru/dev/dialogs/alice/doc/resource-upload.html#http-images-load__auth).
- IoTOAuthToken. Debug token [documentation](https://yandex.ru/dev/id/doc/dg/oauth/tasks/get-oauth-token.html)






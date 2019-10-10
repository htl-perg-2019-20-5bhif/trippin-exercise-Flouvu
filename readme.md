# Trippin Exercise

## Introduction

You are working in a company that uses the [*Trippin* software](https://www.odata.org/odata-services/) to manage travels. You have to write a command-line tool to automate the creation of users.

## Starting point

You have received a JSON [file with all users](users.json).

## Your Job

* Iterate through all users in the file *users.json*
  * For each user, check if the user exists (e.g. for user with *UserName* *russelwhyte*: `https://services.odata.org/TripPinRESTierService/People('russellwhyte')`).
  * If the user exists, do nothing
  * If the user does not exist, add him. Here is an example request for adding a user:

```txt
POST https://services.odata.org/TripPinRESTierService/People
Content-Type: application/json

{
    "UserName":"lewisblack",
    "FirstName":"Lewis",
    "LastName":"Black",
    "Emails":[
        "lewisblack@example.com"
    ],
    "AddressInfo": [
    {
      "Address": "187 Suffolk Ln.",
      "City": {
        "Name": "Boise",
        "CountryRegion": "United States",
        "Region": "ID"
      }
    }
    ]
}
```

## Tips

* See [https://www.odata.org/odata-services/](https://www.odata.org/odata-services/) for sample requests for the *trippin* service
* **Note** that you must [request a key](https://www.odata.org/odata-services/service-usages/request-key-tutorial/) to be able to write data

## Extra Points

Send me a link to the solution via GitHub to receive an extra point for your grade.

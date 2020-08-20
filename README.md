# **API PROJECT / INSTITUTE**

App EntityFrameworck Core Api, ABM of players / representatives / teams with local database.

For a better functioning of the app, unit tests were carried out later.

## **PRE-REQUIREMENTS**

- SQLServer 2017 express
- Visual Studio 2017 
	.Net Core 2.2

## **APIs Summary**

**Methods used to invoke APIs**

**GET**

* to search for resources / details

**POST**

* to create new resource

**PUT**

* to change details of that resource

**PATCH**

* to change partial details of that resource

**DELETE**

* to delete resource

## **How to make use of the API?**

* *The API can be invoked through HTTP GET, POST, PUT and PATCH requests.
All parameters in the request must be encoded by form.*

supports the JSON format and the URL structure for it is given below:
```
URL

https://<Host-Name OR IP address>:<Port>/api/players/<Resource ID>
```

**GET LIST OF RESOURCES**

Description

* To get the list of resources which are owned by or shared to an API user.

```
URL

https://<Host-Name OR IP address>:<Port>/api/players
```

**HTTP Method**

GET

**Input Data**

None

**Sample Output**

In the output (as shown in the sample below), you will get all the resources owned

```
example
{
  "name" : "Pedro" ,

  "surname " : "Gorre",

  "category" : "98",

  "club" : "F.C. Caracas",

  "dominanFood": "Left",
 
  "nationality": "Brasil",

  "representative": "Hernesto Villa",

   "PlayerID": "20" 
   
},
{
  
  "name" : "Pablo " ,

  "surname " : "Svez",

  "category" : "98",

  "club" : "F.C. Caracas",

  "dominanFood": "Right",
 
  "nationality": "Argentina",

  "representative": "Gaston Soprano", 

   "PlayerID": "21"
                              
},
{
  
  "name" : "Nero" ,

  "surname " : "Rolo",

  "category" : "95",

  "club" : "F.C. Caracas",

  "dominanFood": "Left",
 
  "nationality": "E.E.U.U",

  "representative": "Hernesto Villa",

  "PlayerID": "22" 
                              
},
...
...

```
## GET THE DETAIL OF A PARTICULAR RESAOURCE

Description

* *To obtain the detail of a resource, in an http request platform, it is necessary
to have its id (obtained in the GET method of the resource list)* 


**Sample Request**
```
URL

https://<Host-Name OR IP address>:<Port>/api/players/<Resource ID>
```

**HTTP Method**

GET

**Input Data**

Resource ID

**Sample Output**
```
example recourseId : 22


  "name" : "Nero" ,

  "surname " : "Rolo",

  "category" : "95",

  "club" : "F.C. Caracas",

  "dominanFood": "Left",
 
  "nationality": "E.E.U.U",

  "representative": "Hernesto Villa",

  "PlayerID": "22"

```
## ADD A RESOURCE

Description

* *To add a resource, you must enter the resource form in an http request platform in json format*

* *Sample Request*

```
URL

https://<Host-Name OR IP address>:<Port>/api/students/
```

**HTTP Method**

POST

**Input Data**

in json format, you must enter the resource form(the properties of the resource)
```
{
  "name" : "value1 " ,

  "surname " : "value2",

  "category" : "value3",

  "club" : "value4",

  "dominanFood": "value5",
 
  "nationality": "value6",

  "representative": "value7"
}
```
**Sample Output**
```
{
  "name" : "value1 " ,

  "surname " : "value2",

  "category" : "value3",

  "club" : "value4",

  "dominanFood": "value5",
 
  "nationality": "value6",

  "representative": "value7",

  "PlayerID": "new Id"
}

```
**MODIFY AN ENTIRE RESOURCE**

Description

* To modify a complete resource, on an http request platform, you must enter the resource id in 
the url and the resource form in json format in the body of the request


**Sample Output**
```
URL

https://<Host-Name OR IP address>:<Port>/api/players/<Resource ID>
```

**HTTP Method**

PUT

**Input Data**

get the resource using the id and then modify it with the new data in json format, 
you need to enter the resource form (the resource properties)
```
example:

{
  "name" : "Nero" ,

  "surname " : "Rolo",

  "category" : "95",

  "club" : "F.C. Caracas",

  "dominanFood": "Left",
 
  "nationality": "E.E.U.U",

  "representative": "Hernesto Villa",

  "PlayerID": "22"
}

modified with new data

{
  "name" : "newValue1 " ,

  "surname " : "newValue2",

  "category" : "newValue3",

  "club" : "newValue4",

  "dominanFood": "newValue5",

  "nationality": "newValue6",

  "representative": "newValue7"
  
*"PlayerID" no modification necessary
}
```

**Sample Output**
```
{
  "name" : "newValue1 " ,

  "surname " : "newValue2",

  "category" : "newValue3",

  "club" : "newValue4",

  "dominanFood": "newValue5",

  "nationality": "newValue6",

  "representative": "newValue7"

  "PlayerID": "22"
}

```
## MODIFY AN PARTIAL RESOURCE

Description

* *To modify a partial resource, on an http request platform, you must enter the resource id in 
the url and using a patchdocument replace the property of that record*


* *Sample Request*

```
URL

https://<Host-Name OR IP address>:<Port>/api/players/<Resource ID>
```

**HTTP Method**

PATCH

**Input Data**

obtain the resource using the identification and then using json format, you must enter 
the operation / where the patch will be / the value
```
example:
]
    {
	"op" : "Replace" ,
	"path " : "/surname",
 	"value" : "Collins"
    }
]

```

**Sample Output**
```
{
  "name" : "Nero" ,

  "surname " : "Collins",

  "category" : "95",

  "club" : "F.C. Caracas",

  "dominanFood": "Left",
 
  "nationality": "E.E.U.U",

  "representative": "Hernesto Villa",

  "PlayerID": "22"
}

```
## DELETE RESOURCE

Description

* *To delete a resource, on an http request platform, you must search for the resource 
using the id and then delete them with that request.*


**Sample Output**
```
URL

https://<Host-Name OR IP address>:<Port>/api/players/<Resource ID>
```
**HTTP Method**

DELETE

**Input Data**

Resource ID

**Sample Output**
```
NoContent

```
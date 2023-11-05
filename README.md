# Expenses Control API

_Expenses control API_ is an API to track my expenses. 
The solution contains the Api Project and the Rdb Project.

**Api Project** is the project that contains the API(controllers), Services and PersistantServices.

**Rdb Project** contains the Entities and the implementation of the mechanisms to manipulate the 
data within a Relational Database (Postgresql)

### Service vs PersistantServices

PersistantServices contains the interfaces and implementations of the mechanisms to store, retrieve and manipulate
information within a storage that can be a _File_, a _Relational_ or _NonSql Database_

A service contains the interfaces and implementations of the necessary logic to perform an action through 
an API instruction.


#! /bin/bash

mongoimport --host mongodb --db mongodb --collection Product --type json --file /mongodb_Product.json --jsonArray
mongoimport --host mongodb --db mongodb --collection User --type json --file /mongodb_User.json --jsonArray
mongoimport --host mongodb --db mongodb --collection UserGroup --type json --file /mongodb_UserGroup.json --jsonArray
mongoimport --host mongodb --db mongodb --collection Category --type json --file /mongodb_Category.json --jsonArray
print("Started Adding the Users.");
db.getSiblingDB('SettingDB').createUser({user: 'appuser', pwd: 'appuser', roles: [ {role: 'readWrite', db: 'SettingDB'}]});
print("End Adding the User Roles.");
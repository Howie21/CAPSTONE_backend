from django.db import models
from django.contrib.auth.models import AbstractUser

# Create your models here.

# To add new columns to the authentication_user table include the properties
# in the model below
# In order for the new columns to appear in the database run:
# 1. python manage.py makemigrations
# 2. python manage.py migrate


class User(AbstractUser):
    license_number = models.CharField(max_length=20, null=True), 
    age = models.IntegerField(max_length=3, null=True),
    # user_role = models.ForeignKey(Roles, null=True),
    # tenant_information = models.ForeignKey(TenantInformation, null=True),
    # property_number = models.ForeignKey(Property, null=True)
    

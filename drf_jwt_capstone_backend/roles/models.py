from django.db import models

# Create your models here.

class Role(models.Model):
    role_name = models.CharField(max_length=50),
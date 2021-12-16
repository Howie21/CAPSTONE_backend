from rest_framework import serializers
from .models import Role

class RoleSerializer(serializers.ModelSerializer):

    class Meta:
        model = Role
        fields = ['role_name']

    def create(self, validated_data):
        return Role.objects.create(**validated_data)
    
    def update(self, instance, validated_data):
        instance.role_name = validated_data.get('role_name', instance.role_name)
        instance.save()
        return instance

from django.contrib.auth import get_user_model
from .serializers import RegistrationSerializer
from rest_framework import generics
from rest_framework.permissions import AllowAny
from rest_framework.views import APIView
from rest_framework.response import Response
from rest_framework import serializers, status

User = get_user_model()


class RegisterView(generics.CreateAPIView):
    queryset = User.objects.all()
    permission_classes = (AllowAny,)
    serializer_class = RegistrationSerializer


class GetCurrentUser(APIView):
    
    def get(self, request, pk):
        user = User.objects.get(pk=pk)
        serializer = RegistrationSerializer(user)
        return Response(serializer.data)

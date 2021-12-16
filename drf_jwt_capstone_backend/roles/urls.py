from django.urls import path
from .views import RoleCreate, RoleChange
# from .views import 

urlpatterns = [
    path('roleCreate/', RoleCreate.as_view(), name='roleCreate'),
    path('roleEdit/<int:pk>/', RoleChange.as_view(), name='roleChange'),
]
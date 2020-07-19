
import { HttpClient, HttpHeaders } from '@angular/common/http';
export class Constants{
    public static API = 'https://localhost:44399/api/';
    public static HTTP_OPTIONS = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
}
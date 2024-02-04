import { Injectable } from '@angular/core';
import { AddBlogPost } from '../models/add-blog-post.model';
import { Observable, ObservableLike } from 'rxjs';
import { BlogPost } from '../models/blogpost.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { EditBlogPostRequest } from '../models/edit-blogpost-request.model';

@Injectable({
  providedIn: 'root'
})
export class BlogPostService {

  constructor(private http: HttpClient) { }

  createBlogPost(data: AddBlogPost) : Observable<BlogPost>
  {
    return this.http.post<BlogPost>(`${environment.apiBaseUrl}/api/blogposts?addAuth=true`, data);
  }

  getBlogPostById(id: string) : Observable<BlogPost>
  {
    return this.http.get<BlogPost>(`${environment.apiBaseUrl}/api/blogposts/${id}`);
  }

  getBlogPostByUrlHandle(urlHandle: string) : Observable<BlogPost>
  {
    return this.http.get<BlogPost>(`${environment.apiBaseUrl}/api/blogposts/${urlHandle}`);
  }

  updateBlogPost(id: string, updateBlogPostRequest: EditBlogPostRequest): Observable<BlogPost>
  {
    return this.http.put<BlogPost>(`${environment.apiBaseUrl}/api/blogposts/${id}?addAuth=true`, updateBlogPostRequest);
  }

  getAllBlogPosts() : Observable<BlogPost[]>
  {
    return this.http.get<BlogPost[]>(`${environment.apiBaseUrl}/api/blogposts`);
  }

  deleteBlogPost(id: string): Observable<BlogPost>
  {
    return this.http.delete<BlogPost>(`${environment.apiBaseUrl}/api/blogposts/${id}?addAuth=true`);
  }
}

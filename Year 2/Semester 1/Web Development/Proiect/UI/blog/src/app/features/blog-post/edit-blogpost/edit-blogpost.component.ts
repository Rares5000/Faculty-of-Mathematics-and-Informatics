import { Component, OnDestroy, OnInit } from '@angular/core';
import { BlogPostService } from '../services/blog-post.service';
import { CategoryService } from '../../category/services/category.service';
import { ActivatedRoute, Router } from '@angular/router';
import { EditBlogPostRequest } from '../models/edit-blogpost-request.model';
import { Observable, Subscription } from 'rxjs';
import { Category } from '../../category/models/category.model';
import { BlogPost } from '../models/blogpost.model';

@Component({
  selector: 'app-edit-blogpost',
  templateUrl: './edit-blogpost.component.html',
  styleUrls: ['./edit-blogpost.component.sass']
})
export class EditBlogpostComponent implements OnInit, OnDestroy{
  id: string | null = null;
  blogPost?: BlogPost;
  selectedCategories?: string[];
  categories$?: Observable<Category[]>;
  paramsSubscribe?: Subscription;
  isImageSelectorVisible: boolean = false;
  updateBlogPostSubscription?: Subscription;
  getBlogById?: Subscription;
  deleteBlogPostSubscription?: Subscription;

  constructor(private route: ActivatedRoute, private blogPostService: BlogPostService, private categoryService: CategoryService, private router: Router){
  }

  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategories();

    this.paramsSubscribe = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');

        if(this.id){
          this.getBlogById = this.blogPostService.getBlogPostById(this.id)
          .subscribe({
            next: (response) => {
              this.blogPost = response;
              this.selectedCategories = response.categories.map(x => x.id);
            }
          });
        }
      }
    });
  }
  
  onFormSubmit(): void{
    if(this.blogPost && this.id)
    {
      var updateBlogPostRequest: EditBlogPostRequest = {
        author: this.blogPost.author,
        content: this.blogPost.content,
        shortDescription: this.blogPost.shortDescription,
        featuredImageUrl: this.blogPost.featuredImageUrl,
        isVisible: this.blogPost.isVisible,
        publishedDate: this.blogPost.publishedDate,
        title: this.blogPost.title,
        urlHandle: this.blogPost.urlHandle,
        categories: this.selectedCategories ?? []
      };

      console.log(updateBlogPostRequest);
      this.updateBlogPostSubscription = this.blogPostService.updateBlogPost(this.id, updateBlogPostRequest)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/blogposts');
        }
      });
    }
        
  }

  openImageSelector(): void{
    this.isImageSelectorVisible = true;
  }

  closeImageSelector(): void{
    this.isImageSelectorVisible = false;
  }

  onDelete(): void{
    if(this.id)
    {
      this.deleteBlogPostSubscription = this.blogPostService.deleteBlogPost(this.id)
      .subscribe({
        next: (response) =>
        {
          this.router.navigateByUrl('/admin/blogposts');
        }
      })
    }
  }

  ngOnDestroy(): void {
    this.paramsSubscribe?.unsubscribe();
    this.updateBlogPostSubscription?.unsubscribe();
    this.getBlogById?.unsubscribe();
    this.deleteBlogPostSubscription?.unsubscribe();
  }

    
}

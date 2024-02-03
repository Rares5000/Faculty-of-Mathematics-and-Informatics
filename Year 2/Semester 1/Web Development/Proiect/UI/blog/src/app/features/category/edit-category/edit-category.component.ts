import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Category } from '../models/category.model';
import { CategoryService } from '../services/category.service';
import { EditCategoryRequest } from '../models/edit-category-request.model';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.sass']
})
export class EditCategoryComponent implements OnInit, OnDestroy{

  id: string | null = null;
  category?: Category;
  paramsSubscription?: Subscription;
  editCategorySubscription?: Subscription;
  deleteCategorySubscription?: Subscription;

  constructor(private route: ActivatedRoute, private categoryService: CategoryService, private router: Router){
  }

  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');

        if(this.id){
          this.categoryService.getCategoryById(this.id)
          .subscribe({
            next: (response) => {
              this.category = response;
            }
          });
        }

      }
    });
  }

  onFormSubmit(): void{
    const updateCategoryRequest: EditCategoryRequest = {
      name: this.category?.name ?? '',
      urlHandle: this.category?.urlHandle ?? ''
    };

    if(this.id){
      this.editCategorySubscription = this.categoryService.updateCategory(this.id, updateCategoryRequest)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/categories');
        }
      });
    }
  }

  onDelete(): void{
    if(this.id != null)
    {
      this.deleteCategorySubscription = this.categoryService.deleteCategory(this.id)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/categories');
        }
      });
    }
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editCategorySubscription?.unsubscribe();
    this.deleteCategorySubscription?.unsubscribe();
  }

}

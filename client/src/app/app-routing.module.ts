import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GalleryComponent } from './components/gallery/gallery.component';
import { PictureDiscussionComponent } from './components/picture-discussion/picture-discussion.component';

const routes: Routes = [
  {
    path: '',
    component: GalleryComponent,
  },
  {
    path: 'picture-discussion',
    component: PictureDiscussionComponent,
  },
  {
    path: 'gallery',
    component: GalleryComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

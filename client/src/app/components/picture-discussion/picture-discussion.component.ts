import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PicturesService } from 'src/app/services/pictures.service';

@Component({
  selector: 'app-picture-discussion',
  templateUrl: './picture-discussion.component.html',
  styleUrls: ['./picture-discussion.component.scss'],
})
export class PictureDiscussionComponent implements OnInit {
  selectedPicture: any;
  newMessage: string = '';
  resolution: number = 0;

  constructor(private picturesService: PicturesService, private router: Router) {
  }

  ngOnInit(): void {
    this.picturesService.selectedPicture$.subscribe(image => {
      this.selectedPicture = image;
    });
  }

  onBack() {
    this.router.navigate(['/gallery']);
  }

  getData(imageElement: HTMLImageElement) {
    this.selectedPicture.height = imageElement.height;
    this.selectedPicture.width = imageElement.width;
    const width = imageElement.naturalWidth;
    const height = imageElement.naturalHeight;
    this.selectedPicture.resolution = width * height;
  }
}

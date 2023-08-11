import { Component, OnInit } from '@angular/core';
import { Picture } from '../../interfaces/picture';
import { Router } from '@angular/router';
import { PicturesService } from 'src/app/services/pictures.service';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.scss']
})
export class GalleryComponent implements OnInit {
  pictures: Picture[] = [];
  filteredPictures: Picture[] = [];
  searchTerm: string = '';

  constructor(private router: Router, private picturesService: PicturesService) { }

  ngOnInit(): void {
    this.picturesService.getPictures().subscribe(pictures => {
      this.pictures = pictures;
    });
  }

  onSelectedPicture(picture: Picture) {
    this.picturesService.setSelectedPicture(picture);
    this.router.navigate(['/picture-discussion']);
  }
}


import { Component, inject, OnInit } from '@angular/core';
import { MembersService } from '../../_services/members.service';
import { Member } from '../../_models/member';
import { MemberCardComponent } from '../member-card/member-card.component';

@Component({
  selector: 'app-member-list',
  standalone: true,
  imports: [MemberCardComponent],
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.css',
})
export class MemberListComponent implements OnInit {
  memberServices = inject(MembersService);

  ngOnInit(): void {
    if (this.memberServices.members().length == 0) this.loadMember();
  }
  loadMember() {
    this.memberServices.getMembers();
  }
}

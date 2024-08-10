namespace alimenta_bem.src.donation.repository;

public interface IDonationData
{
    Task<Donation> Create(Donation donation);
}